----Object Painter Code Sample----
The purpose of this project is to allow the user to use a colour or material and paint a selected object.

--Code Details--
Painter 
This will control the flow of the application. It will hold references to the Palette and PaletteDisplay classes. It also receives an OnClick event for when the pointer is pressed. If the pointer is over a part when pressed it will update its colour or texture.

PaletteDisplay 
Controls updating the UI from a Palette reference it receives from the Painter as well as changing the selectedPaintIndex integer stored in the Painter. It will hold a UI prefab and spawn it in to match the length of the IPaint array in the Palette. Paint(Image) will then be called on each of the IPaint array items to add the colour/texture to the UI Icon.

Palette 
Holds a PaletteData object and an array for IPaint. 

PaletteData 
This is a ScriptableObject allowing for different types of data to be created and stored and swapped out on the Painter object as required. PaletteData will have two arrays, one for Texture2DPaint and one for colourPaint. Texture2DPaint and ColourPaint both inherit from IPaint but implement an extra variable each for their type. 

The Palette IPaint array will be generated at runtime by combining both the two arrays in PaletteData. It is also the only thing that the Painter and PaletteDisplay classes should access. This means that when the Painter wants to change the colour of a part they only need to call the Paint(Material) function on the Palette IPaint array item at index selectedPaintIndex and pass in the material.

