# Ignite UI Theme Service by Infragistics
The main goal of the Ignite UI Theme Service is to serve your Ignite UI for Angular app with a theme in CSS format. The service will be available as a standalone web application supporting the creation of themes and configuration of their different stylistical aspects, where at the final step it will be possible to download the created theme in CSS format.

The Theme Service will come with an API, making it possible to e.g. create your own widget exposing selected theming properties and creating a theme that could be applied to change the looks of your app.

There are are 4 distinct aspects of a theme:
* Color Palettes
* Typographies
* Rounding
* Elevation

## Requirements
In order to run the project you'll need:
* Visual Studio 2017
* ASP.NET Core 2.0

## Parameters
The theming service API is available at `~/api/taas` and it takes the following parameters:

| parameter   | type   | description |
| --------:   | ----   | ----------- |
| isDarkTheme | bool   | whether the preset theme will be light or dark |
| colors      | Colors | there are seven colors which can be specified in order to build a custom palette for your custom theme - Primary, Secondary, Surface, Error, Success, Warn, Info |
| typeface    | string | the name of the font |
| roundness   | float  | global roundness factor for all of the components, the values it takes are from 0 to 1 |
| elevation   | int    | global elevation factor for all of the components, the values are integer - from 0 to 24 |

## Example
Here's an example of the requiest with all of the parameters specified:
```
http://localhost:2602/api/taas?isDarkTheme=false&colors.Primary=%23231736&colors.Secondary=%23f542bf&colors.Surface=%2342f5e3&colors.Error=%23f54242&colors.Success=%23f54242&colors.Warn=%237a0004&colors.Info=%235a4db8&typeface=Roboto&roundness=0.5&elevation=0
```
