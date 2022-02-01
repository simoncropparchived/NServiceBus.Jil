# <img src="/src/icon.png" height="30px"> NServiceBus.Jil

[![Build status](https://ci.appveyor.com/api/projects/status/oab6rmnc297vyyh5/branch/main?svg=true)](https://ci.appveyor.com/project/SimonCropp/nservicebus-Jil)
[![NuGet Status](https://img.shields.io/nuget/v/NServiceBus.Jil.svg)](https://www.nuget.org/packages/NServiceBus.Jil/)

Add support for [NServiceBus](https://particular.net/NServiceBus) message serialization via [Jil](https://github.com/kevin-montrose/Jil)


<!--- StartOpenCollectiveBackers -->

[Already a Patron? skip past this section](#endofbacking)


## Community backed

**It is expected that all developers either [become a Patron](https://opencollective.com/nservicebusextensions/contribute/patron-6976) to use NServiceBusExtensions. [Go to licensing FAQ](https://github.com/NServiceBusExtensions/Home/#licensingpatron-faq)**


### Sponsors

Support this project by [becoming a Sponsor](https://opencollective.com/nservicebusextensions/contribute/sponsor-6972). The company avatar will show up here with a website link. The avatar will also be added to all GitHub repositories under the [NServiceBusExtensions organization](https://github.com/NServiceBusExtensions).


### Patrons

Thanks to all the backing developers. Support this project by [becoming a patron](https://opencollective.com/nservicebusextensions/contribute/patron-6976).

<img src="https://opencollective.com/nservicebusextensions/tiers/patron.svg?width=890&avatarHeight=60&button=false">

<a href="#" id="endofbacking"></a>

<!--- EndOpenCollectiveBackers -->


## Usage

snippet: JilSerialization


### Custom settings

Customizes the instance of `Options` used for serialization.

snippet: JilCustomSettings


### Custom reader

Customize the creation of the [JsonReader](https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_JsonReader.htm).

snippet: JilCustomReader


### Custom writer

Customize the creation of the [JsonWriter](https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_JsonWriter.htm).

snippet: JilCustomWriter


### Custom content key

When using [additional deserializers](https://docs.particular.net/nservicebus/serialization/#specifying-additional-deserializers) or transitioning between different versions of the same serializer it can be helpful to take explicit control over the content type a serializer passes to NServiceBus (to be used for the [ContentType header](https://docs.particular.net/nservicebus/messaging/headers#serialization-headers-nservicebus-contenttype)).

snippet: JilContentTypeKey


## Currently not supported

Usages of `DataBusProperty<T>` are not supported since it doesn't have a default constructor. However usage of the [databus convention](https://docs.particular.net/nservicebus/messaging/databus) is supported.


## Icon

[Eagle](https://thenounproject.com/term/eagle/58506/) designed by [m. turan ercan](https://thenounproject.com/mte/) from [The Noun Project](https://thenounproject.com).