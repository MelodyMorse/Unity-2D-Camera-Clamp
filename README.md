# Unity 2D Camera Clamp
##### A monobehavior that clamps the camera to a specified area

Put CameraClamp.cs on a camera Gameobject to clamp it to specified minimum and maximum coordinates.  Adjust camera bounds with variables xMin, xMax, yMin, yMax.  These values indicate the world space coordinates that the edges of the camera can not exceed. A custom gizmo renders a green rectangle that shows the current bounds of the camera

##### Notes:
* Designed for use with orthographic camera.
* Camera is clamped in LateUpdate. This is to avoid flickering.  Ensure that your camera movement code runs before the camera clamping code. 
* Ensure that the bounds are larger than the camera’s view.  Else camera will flicker and become uncontrollable. Functionality has been added to help prevent this, but in some cases this glitch still occurs.
* In the editor camera clamp handles will overlap camera handles in certain situations, mostly when MinX, MaxX, MinY and MaxY are set to default or the camera starts at the bounds of the clamp. If you use either handle in these situations take care to select the right one (The camera clamp handle is the one on the green rectangle) 
* This script does not support changing the size of the camera during gameplay or changing the viewport rect to anything other than default
