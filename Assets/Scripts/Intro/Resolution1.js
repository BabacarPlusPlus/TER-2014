#pragma strict

var GuiTexture : Texture2D;
 
function OnGUI()
{
    GUI.DrawTexture(ResizeGUI(Rect(Screen.width/5, Screen.height/3, 500, 300)), GuiTexture);
}    
 
function ResizeGUI(_rect : Rect) : Rect
{
    var FilScreenWidth = _rect.width / 1024;
    var rectWidth = FilScreenWidth * Screen.width;
    var FilScreenHeight = _rect.height / 768;
    var rectHeight = FilScreenHeight * Screen.height;
    var rectX = (_rect.x / 1024) * Screen.width;
    var rectY = (_rect.y / 768) * Screen.height;
 
    return Rect(rectX,rectY,rectWidth,rectHeight);
}
