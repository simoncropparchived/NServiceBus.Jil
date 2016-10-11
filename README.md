![Icon](https://raw.githubusercontent.com/SimonCropp/NServiceBus.Jil/master/Icon/package_icon.png)

NServiceBus.Jil
===========================

Add support for [NServiceBus](http://particular.net/NServiceBus) message serialization via [Jil](https://github.com/kevin-montrose/Jil)


## The nuget package  [![NuGet Status](http://img.shields.io/nuget/v/NServiceBus.Jil.svg?style=flat)](https://www.nuget.org/packages/NServiceBus.Jil/)

https://nuget.org/packages/NServiceBus.Jil/

    PM> Install-Package NServiceBus.Jil


## Usage

```
var busConfig = new BusConfiguration();
busConfig.UseSerialization<JilSerializer>();
```


### Customisation 


    busConfig.UseSerialization<JilSerializer>()
        .Options(
            new Options(
                prettyPrint: true,
                excludeNulls: true,
                includeInherited: true));


## Currently not supported

Usages of `DataBusProperty<T>` since it doesn't have a default constructor. However usage of the [databus convention](https://docs.particular.net/nservicebus/messaging/databus) is supported.


## Icon

<a href="http://thenounproject.com/term/eagle/58506/" target="_blank">Eagle</a> designed by <a href="http://thenounproject.com/mte/" target="_blank">m. turan ercan</a> from The Noun Project