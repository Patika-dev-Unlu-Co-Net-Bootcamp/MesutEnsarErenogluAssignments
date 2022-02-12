## Hafta 5 [Ödev](https://github.com/Patika-dev-Unlu-Co-Net-Bootcamp/MesutEnsarErenogluAssignments/tree/main/UnluCo.Bootcamp.Hafta5.Odev)

- Tek bir endpoint ten arama, filtreleme ve sıralama işlemlerini yapılan generic method yazıldı.
(/Common/Extensions/FilterDataExtension.cs ) Bu method db'ye yapılan her sorgu için kullanılabilir. 

    * FilterResponseModel, FilterQueryParams, FilterPaggingInfo classları oluşturuldu.
    ```
    public class FilterPaggingInfo
    {
        
        public int TotalItemCount { get; set; } = 0;
        public int TotalPageCount { get; set; } = 1;

        public int CurrentPage { get; set; } = 1;

        private int _nextPage;
        public int NextPage
        {
            get
            {
                _nextPage = CurrentPage == TotalPageCount ? CurrentPage : CurrentPage + 1;
                return _nextPage;
            }
        }

        private int _previousPage;

        public int PreviousPage
        {
            get
            {
                _previousPage = CurrentPage == 1 ? CurrentPage : CurrentPage - 1;
                return _previousPage;
            }
        }
    }
    ```

    ```
    public class FilterQueryParams
    {
        public int PageSize { get; set; } = 10;
        public int Page { get; set; } = 1;
        public string[] SortOptions { get; set; } = null; 
        public bool SortingDirection { get; set; } = false; //false = asc, true = desc
        public string SearchValue { get; set; } = null;
    }
    ```

    ```
    public class FilterResponseModel<T> where T: class
    {
        public List<T> DataList { get; set; }

        public FilterPaggingInfo PaggingInfo { get; set; }
    }
    ```
    * FilterDataExtension adında IQueryable extend eden method yazıldı.
    ```
    public static FilterResponseModel<T> GetDataAndPaggingInfo<T> (this IQueryable<T> dbEntities,FilterQueryParams queryParams) where T : class
        {
            FilterResponseModel<T> filterResponse = new FilterResponseModel<T>();
            var entity = typeof(T);
            PropertyInfo[] properties = entity.GetProperties();
            var searchProps = new List<PropertyInfo>();

            foreach (var prop in properties)
            {
                var attribute = prop.GetCustomAttribute(typeof(CustomSearchPropertyAttribute),false);
                if (attribute != null)
                {
                    searchProps.Add(prop);
                }
            }

            //Search

            if (!string.IsNullOrEmpty(queryParams.SearchValue) && searchProps.Count > 0)
            {
                ConstantExpression constant = Expression.Constant(queryParams.SearchValue.ToLower());
                ParameterExpression parameter = Expression.Parameter(typeof(T), "e");
                MemberExpression[] members = new MemberExpression[searchProps.Count];
                MethodInfo containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                MethodInfo toLowerMethod = typeof(string).GetMethod("ToLower", System.Type.EmptyTypes);

                for (int i = 0; i < searchProps.Count(); i++)
                {
                    members[i] = Expression.Property(parameter, searchProps[i]);
                }

                Expression predicate = null;
                foreach (var member in members)
                {
                    //e => e.Member != null
                    BinaryExpression notNullExp = Expression.NotEqual(member, Expression.Constant(null));
                    //e => e.Member.ToLower() 
                    MethodCallExpression toLowerExp = Expression.Call(member, toLowerMethod);
                    //e => e.Member.Contains(value)
                    MethodCallExpression containsExp = Expression.Call(toLowerExp, containsMethod, constant);
                    //e => e.Member != null && e.Member.Contains(value)
                    BinaryExpression filterExpression = Expression.AndAlso(notNullExp, containsExp);
                    predicate = predicate == null ? (Expression)filterExpression : Expression.OrElse(predicate, filterExpression);

                }
                var lambda = Expression.Lambda<Func<T, bool>>(predicate, parameter);

                filterResponse.DataList = dbEntities.Where(lambda).Skip((queryParams.Page - 1) * queryParams.PageSize).Take(queryParams.PageSize).ToList();
            }

            //Pagging

            if (filterResponse.DataList == null)
            {
                filterResponse.DataList = dbEntities.Skip((queryParams.Page - 1) * queryParams.PageSize).Take(queryParams.PageSize).ToList();
            }

            FilterPaggingInfo paggingInfo = new FilterPaggingInfo();
            paggingInfo.TotalItemCount = dbEntities.Count();
            paggingInfo.CurrentPage = queryParams.Page;
            paggingInfo.TotalPageCount = (int)Math.Ceiling((double)(dbEntities.Count() / queryParams.PageSize));

            filterResponse.PaggingInfo = paggingInfo;

            //Sort
            if (queryParams.SortOptions != null && queryParams.SortOptions.Length > 0)
            {
                
                foreach (var item in queryParams.SortOptions)
                {
                    var property = entity.GetProperty(item.Trim());

                    if (!queryParams.SortingDirection)
                    {
                        filterResponse.DataList = filterResponse.DataList.OrderBy(x => property.GetValue(x, null)).ToList();
                    }
                    else
                    {
                        filterResponse.DataList = filterResponse.DataList.OrderByDescending(x => property.GetValue(x, null)).ToList();
                    }
                }
            }

            return filterResponse;
        }
    ```
    * GetMoviesByFilterQuery class'ında kullanıldı. 
    ```
    public class GetMoviesByFilterQuery
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public FilterQueryParams Params { get; set; }


        public GetMoviesByFilterQuery(AppDbContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public FilterResponseModel<GetMoviesbyFilterQueryVM> Handle()
        {
         
            FilterResponseModel<Movie> movieReponse = _db.Movies.Include(x=>x.Director).Include(x=>x.Genre).GetDataAndPaggingInfo<Movie>(Params);
            var responseModels = _mapper.Map<List<GetMoviesbyFilterQueryVM>>(movieReponse.DataList);

            FilterResponseModel<GetMoviesbyFilterQueryVM> vmResponse = new FilterResponseModel<GetMoviesbyFilterQueryVM>();
            vmResponse.DataList = responseModels;
            vmResponse.PaggingInfo = movieReponse.PaggingInfo;

            foreach (var item in vmResponse.DataList)
            {
                item.ActorNames = _db.MovieAndActors.Where(x => x.Movie.MovieName == item.MovieName).Select(x => x.Actor.FullName).ToArray();
                
            }
            return vmResponse;
        }
    }
    ```
- In memorycache ve response cache kullanımları yapıldı. (GetMoviesbyFilter - Response Cache / GetMoviebyId - Memory Cache)

```
        [HttpGet]
        [ResponseCache(Duration = 30000, Location = ResponseCacheLocation.Client, NoStore = false)]
        public IActionResult GetMoviesbyFilter([FromQuery] FilterQueryParams queryParams)
        {
            GetMoviesByFilterQuery query = new GetMoviesByFilterQuery(_db, _mapper);
            query.Params = queryParams;
            var response = query.Handle();

            Response.Headers.Add("PaggingInfo", System.Text.Json.JsonSerializer.Serialize(response.PaggingInfo));
            return Ok(response.DataList);
        }
```

```
        [HttpGet("{movieId}")]
        public IActionResult GetMoviebyId(int movieId)
        {
            _memoryCache.TryGetValue($"GetMovieDetail{movieId}", out GetMovieDetailQueryVM vm);

            if (vm == null)
            {
                GetMovieDetailQuery query = new GetMovieDetailQuery(_db, _mapper);
                query.MovieId = movieId;
                GetMovieDetailQueryValidator validator = new GetMovieDetailQueryValidator();
                validator.ValidateAndThrow(query);

                vm = query.Handle();
                _memoryCache.Set($"GetMovieDetail{movieId}", vm, new MemoryCacheEntryOptions {
                     AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60),
                     Priority = CacheItemPriority.Normal
                });
            }
            
            return Ok(vm);
        }
```

- Sorgu adedi 100'ü geçtiğinde distributed cache olarak redis e yazan ve okuyan bir cache kullanıldı. (GetMovies)
```
        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var moviesFromCache = await _distributedCache.GetAsync("movies");
            if (moviesFromCache == null)
            {
                GetMoviesQuery query = new GetMoviesQuery(_db, _mapper);
                var result = query.Handle();
                if (result.Count >= 100) 
                {
                   await _distributedCache.SetAsync("movies", Encoding.UTF8.GetBytes(System.Text.Json.JsonSerializer.Serialize(result)));
                }
                return Ok(result);
            }
            var movies = System.Text.Json.JsonSerializer.Deserialize<List<GetMoviesQueryVM>>(moviesFromCache);

            return Ok(movies);

        }
```