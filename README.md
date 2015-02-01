![Icon](https://raw.githubusercontent.com/SimonCropp/NServiceBus.Jil/master/Icon/package_icon.png)

NServiceBus.Jil
===========================

Add support for [NServiceBus](http://particular.net/NServiceBus) message serialization via [Jil](https://github.com/kevin-montrose/Jil)

## Nuget

### http://nuget.org/packages/NServiceBus.Jil/

    PM> Install-Package NServiceBus.Jil

## Usage

```
var busConfig = new BusConfiguration();
busConfig.UseSerialization<JilSerializer>();
```

## Icon

<a href="http://thenounproject.com/term/eagle/58506/" target="_blank">Eagle</a> designed by <a href="http://thenounproject.com/mte/" target="_blank">m. turan ercan</a> from The Noun Project
