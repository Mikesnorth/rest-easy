# RestEasy

A simple library of tools designed to make RESTful web services easier to consume or provide.

## RestEasy.Core

#### Resource
The resource class is an abstract class that makes RESTful resource links available to each derived class. If our resource is `Book`, which has a collection of `Chapter` resources, then our JSON would resemble:
```
{
	"id": 5,
    "title": "RESTful Web Services",
	"_links": {
 		"self": "http://domain.com/books/2",
        "chapter1": "http://domain.com/books/2/chapters/1",
        "chapter2": "http://domain.com/books/2/chapters/2",
    }
}
```

#### IResourceBuilder
The `IResourceBuilder`, and `IResourceBuilderInstance`, define a fluent API for constructing resources. The builder contains a single method, `For<TResource>()`, which creates and returns an instance of `IResourceBuilderInstance<TResource>` for use with the actual resource contstruction.

#### IResourceBuilderInstance
The `IResourceBuilderInstace<>`, exposes an API for adding links to a resource and to trigger the actual construction of the resource in a fluent fashion.

`WithLink(string resourceName, Uri resourceUri)` was used in the example above to add the self and chapter links to the _links_ section.

`Build(Action<TResource> translation)` is used to do any type of translation on the resource before it is returned. This is useful when translating domain entities to REST resources without exposing intimate details of the entity to the resource or vise versa. A manual application for the previous example may be as follows:
```
var bookResource = new ResourceBuilder().For<SomeResource>()
	.Build(resource => {
    	resource.Id = bookEntity.Id;
        resource.Title = bookEntity.Title;
    });
```