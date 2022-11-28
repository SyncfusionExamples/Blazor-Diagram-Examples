# Export the diagram with HTML Nodes

This sample demonstrate how to export the diagram which contains HTML nodes


We don’t have support to export the HTML nodes. We have tried a workaround solution for this case. 

In this sample, We have converted the diagram to as HTML string using HtmlToPdfConverter. HTMLTOPDFConverter has Blink engine. It allows for the conversion of HTML strings into images. Using this converter we have achieved to convert the HTML content of the div (which holds the diagram inside) to image format. 



Export HTML nodes:
![image](https://user-images.githubusercontent.com/77827252/204244908-9326c76f-13d2-421a-a49f-e871193f7e82.png)



## Prerequisites

* Visual Studio 2022

## How to run the project

* Checkout this project to a location in your disk.
* Open the solution file using the Visual Studio 2022.
* Restore the NuGet packages by rebuilding the solution.
* Run the project.