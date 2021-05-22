<!--
GENERATED FILE - DO NOT EDIT
This file was generated by [MarkdownSnippets](https://github.com/SimonCropp/MarkdownSnippets).
Source File: /readme.source.md
To change this file edit the source file and then run MarkdownSnippets.
-->

# <img src="/src/icon.png" height="30px"> NServiceBus.Jil

[![Build status](https://ci.appveyor.com/api/projects/status/oab6rmnc297vyyh5/branch/master?svg=true)](https://ci.appveyor.com/project/SimonCropp/nservicebus-Jil)
[![NuGet Status](https://img.shields.io/nuget/v/NServiceBus.Jil.svg)](https://www.nuget.org/packages/NServiceBus.Jil/)

Add support for [NServiceBus](https://particular.net/NServiceBus) message serialization via [Jil](https://github.com/kevin-montrose/Jil)


<!--- StartOpenCollectiveBackers -->

[Already a Patron? skip past this section](#endofbacking)


## Community backed

**It is expected that all developers either [become a Patron](https://opencollective.com/nservicebusextensions/contribute/patron-6976) or have a [Tidelift Subscription](#support-via-tidelift) to use NServiceBusExtensions. [Go to licensing FAQ](https://github.com/NServiceBusExtensions/Home/#licensingpatron-faq)**


### Sponsors

Support this project by [becoming a Sponsor](https://opencollective.com/nservicebusextensions/contribute/sponsor-6972). The company avatar will show up here with a website link. The avatar will also be added to all GitHub repositories under the [NServiceBusExtensions organization](https://github.com/NServiceBusExtensions).


### Patrons

Thanks to all the backing developers. Support this project by [becoming a patron](https://opencollective.com/nservicebusextensions/contribute/patron-6976).

<img src="https://opencollective.com/nservicebusextensions/tiers/patron.svg?width=890&avatarHeight=60&button=false">

<a href="#" id="endofbacking"></a>

<!--- EndOpenCollectiveBackers -->


## Usage

<!-- snippet: JilSerialization -->
<a id='snippet-jilserialization'></a>
```cs
configuration.UseSerialization<JilSerializer>();
```
<sup><a href='/src/Tests/Snippets/Usage.cs#L11-L15' title='Snippet source file'>snippet source</a> | <a href='#snippet-jilserialization' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Custom settings

Customizes the instance of `Options` used for serialization.

<!-- snippet: JilCustomSettings -->
<a id='snippet-jilcustomsettings'></a>
```cs
var options = new Options(
    prettyPrint: true,
    dateFormat: DateTimeFormat.MicrosoftStyleMillisecondsSinceUnixEpoch,
    includeInherited: true);

var serialization = configuration.UseSerialization<JilSerializer>();
serialization.Options(options);
```
<sup><a href='/src/Tests/Snippets/Usage.cs#L20-L30' title='Snippet source file'>snippet source</a> | <a href='#snippet-jilcustomsettings' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Custom reader

Customize the creation of the [JsonReader](https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_JsonReader.htm).

<!-- snippet: JilCustomReader -->
<a id='snippet-jilcustomreader'></a>
```cs
var serialization = configuration.UseSerialization<JilSerializer>();
serialization.ReaderCreator(stream => new StreamReader(stream, Encoding.UTF8));
```
<sup><a href='/src/Tests/Snippets/Usage.cs#L35-L40' title='Snippet source file'>snippet source</a> | <a href='#snippet-jilcustomreader' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Custom writer

Customize the creation of the [JsonWriter](https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_JsonWriter.htm).

<!-- snippet: JilCustomWriter -->
<a id='snippet-jilcustomwriter'></a>
```cs
var serialization = configuration.UseSerialization<JilSerializer>();
serialization.WriterCreator(stream => new StreamWriter(stream, Encoding.UTF8));
```
<sup><a href='/src/Tests/Snippets/Usage.cs#L45-L50' title='Snippet source file'>snippet source</a> | <a href='#snippet-jilcustomwriter' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Custom content key

When using [additional deserializers](https://docs.particular.net/nservicebus/serialization/#specifying-additional-deserializers) or transitioning between different versions of the same serializer it can be helpful to take explicit control over the content type a serializer passes to NServiceBus (to be used for the [ContentType header](https://docs.particular.net/nservicebus/messaging/headers#serialization-headers-nservicebus-contenttype)).

<!-- snippet: JilContentTypeKey -->
<a id='snippet-jilcontenttypekey'></a>
```cs
var serialization = configuration.UseSerialization<JilSerializer>();
serialization.ContentTypeKey("custom-key");
```
<sup><a href='/src/Tests/Snippets/Usage.cs#L55-L60' title='Snippet source file'>snippet source</a> | <a href='#snippet-jilcontenttypekey' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


## Currently not supported

Usages of `DataBusProperty<T>` are not supported since it doesn't have a default constructor. However usage of the [databus convention](https://docs.particular.net/nservicebus/messaging/databus) is supported.


## Icon

[Eagle](https://thenounproject.com/term/eagle/58506/) designed by [m. turan ercan](https://thenounproject.com/mte/) from [The Noun Project](https://thenounproject.com).
