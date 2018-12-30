# WordPressReader (Standard) 

WordPressReaderStd aims to simplify development of WordPress reader apps. It is written and compiled with .netStandard 1.4 to enable usage of it everywhere you can use .netStandard libraries. The only dependecy it has is Newtonsoft.Json just because you cannot find any better json-library out there.

The library is also available on [Nuget](https://www.nuget.org/packages/WordPressReader/)

## Features:

1. get and filter:
  + posts
  + pages
  + comments
  + categories
  + media
  + tags
  + basic user info
  
2. Allows anonymous commenting (requires additional setup on the WordPress site, though)
3. MVVM-ready model implementation
4. Contains some (quite useful) extensions and helpers
5. Completely async

### Basic usage:

All handlers follow the same principle:


```csharp 
//instantiate a handler
var handler = new PostsHandler();

//MVVMLight (or any other Locator):
SimpleIoc.Default.Register<IPostsHandler>(()=> new PostsHandler());

//get the latest or filtered data
var latestPosts = await _postsHandler.GetPostsAsync(BaseUrl, 20, 20, 1, categories);
```

You can get a more detailed overview in the [Wiki](https://github.com/MSiccDev/WordPressReaderStd/wiki)


If you are experiencing difficulties or have ideas, feel free to contribute via issues or even pull requests.

### Happy coding, everyone!




  

