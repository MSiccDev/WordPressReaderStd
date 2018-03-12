# WordPressReaderStd (netStandard 1.4) v1.0.0

WordPressReaderStd aims to simplify development of WordPress reader apps. It is written and compiled with .netStandard 1.4 to enable usage of it everywhere you can use .netStandard libraries. The only dependecy it has is Newtonsoft.Json just because you cannot find any better json-library out there.

Currently, the library is only available here, but it will be soon available on Nuget as well.

#### Note: this is a v1.0-release, there may be bugs.

## Features:

1. Fetch and filter:
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
That's it!


All Handlers are fully commented with their parameters which should help to use the library until the documentation is ready (work in progress, will be in the Wiki here once it is ready).

If you are experiencing difficulties or have ideas, feel free to contribute via issues or even pull requests.

### Happy coding, everyone!




  

