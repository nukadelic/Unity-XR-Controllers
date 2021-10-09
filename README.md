# XR Controllers

Models from steamVR and oculusSDK, if you have more share your models / colormaps / controller align transformation offsets* and i will include them here ( feel free to open an issue or due a merge request )  

Create low res colormaps for the controller and customize the look when creating a new material by adjusting the color values ( see example preview image below of the shader )  

No input bindings or any vr framework dependancy , nor im planning adding any right now - this is meant to be a collection of 3d models , rotation offsets to fix in game aligning for different plugins ( for example in my case both the Open XR Loader and Oculus Loader needs adjusting ) 

The shader graphs should work in hdrp but currenly the materials are only for URP    

<img src="https://raw.githubusercontent.com/nukadelic/Unity-XR-Controllers/master/doc~/img/preview.png" width="450">
.  

* Planned to add controller hints locations per controller that highlight the inputs in runtime
* Planned to add auto aligner script per xr loader ( its really just a string comparison with `UnityEngine.XR.Management.XRGeneralSettings.Instance.Manager.activeLoader.name` ... but it would be useful to have all the variations stored in one place and updated when needed to include more runtims / headsets in the future ) 
