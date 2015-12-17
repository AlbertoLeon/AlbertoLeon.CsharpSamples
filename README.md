# AlbertoLeon.CsharpSamples
Experiments and samples of C# and .Net implementations for patterns and technologies

#2015-12-17
###Added
[AutofacOwnedScopes](https://github.com/AlbertoLeon/AlbertoLeon.CsharpSamples/tree/master/AutofacOwnedScopes "Autofac Owned Instance for DbContext"), an Autofac sample of isolate a DbContext to guarantee a clean set of entities inside a CommandHandler but mantaining the Dependency Injection and IoC. It uses Autofac Owned Instances to get unique instances to the Command Handler Execute method
