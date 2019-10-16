<img src="/src/icon.png" height="25px"> Add support for [NServiceBus](https://particular.net/NServiceBus) message serialization via [Jil](https://github.com/kevin-montrose/Jil)

<!--- StartOpenCollectiveBackers -->

[Already a Patron? skip past this section](#endofbacking)


## Community backed

**It is expected that all developers [become a Patron](https://opencollective.com/nservicebusextensions/order/6976) to use any of these libraries. [Go to licensing FAQ](https://github.com/NServiceBusExtensions/Home/blob/master/readme.md#licensingpatron-faq)**


### Sponsors

Support this project by [becoming a Sponsors](https://opencollective.com/nservicebusextensions/order/6972). The company avatar will show up here with a link to your website. The avatar will also be added to all GitHub repositories under this organization.


### Patrons

Thanks to all the backing developers! Support this project by [becoming a patron](https://opencollective.com/nservicebusextensions/order/6976).

<img src="https://opencollective.com/nservicebusextensions/tiers/patron.svg?width=890&avatarHeight=60&button=false">

<!--- EndOpenCollectiveBackers -->

<a href="#" id="endofbacking"></a>

toc


## NuGet package

https://nuget.org/packages/NServiceBus.Jil/ [![NuGet Status](https://img.shields.io/nuget/v/NServiceBus.Jil.svg)](https://www.nuget.org/packages/NServiceBus.Jil/)


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


include: custom-contenttype-key

snippet: JilContentTypeKey


## Currently not supported

Usages of `DataBusProperty<T>` are not supported since it doesn't have a default constructor. However usage of the [databus convention](/nservicebus/messaging/databus) is supported.


## Icon

[Eagle](https://thenounproject.com/term/eagle/58506/) designed by [m. turan ercan](https://thenounproject.com/mte/) from [The Noun Project](https://thenounproject.com).