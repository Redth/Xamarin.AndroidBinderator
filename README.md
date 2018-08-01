# Xamarin.AndroidBinderator

An engine to generate Xamarin Binding projects from Maven repositories with a JSON config and razor templates.


## Features
 - Dependency chain automatically inferred from Maven
 - Simple JSON Config file to list Maven artifacts to generate binding projects for


## Usage

### JSON Config File

The JSON Config file (`config.json`) should contain information about all of the Maven artifacts you would like to generate binding projects for.

The config file also should contain Maven artifact information for any dependencies required by the bindings to be generated, which you do not also want to generate bindings for.  You must specify the Maven `groupId`, `artifactId`, and `version` you want to _binderate_,


For example if you have a Maven artifact you want _Binderate_, which depends on  Android Support v4, you can specify this artifact in the config file like this:

```json
{
    "groupId" : "com.android.support",
    "artifactId" : "support-v4",
    "version" : "26.1.0",
    "nugetId" : "Xamarin.Android.Support.v4",
    "nugetVersion" : "27.0.2",
    "dependencyOnly" : true
},
```

Notice we specified that this is a `dependencyOnly`, which means it won't have a binding generated for it, and we specified a `nugetVersion` to use in the `PackageReference`, even though the `version` is different, since this is the version that the maven artifact depending on this package is looking for to satisfy the dependency.



