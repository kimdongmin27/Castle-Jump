# Game Overview
It is a game where you move through each city safely and without accidents to the destination. \
The difficulty level is set according to each city, and you can get rewards by clearing the quests.

***Optimization overview***
 - The canvas was divided and managed.
 - Implemented object pooling as a queue.

***SDK Used***
 - Newtonsoft JSON

***Game Sound***
 - Create a sound class, set audio clips and string variables, and then create an array to output sound when the parameters of the function that actually output the sound and the
   string variable of the sound class match.

***Game Function***
 - I set it to be able to control the volume.
 - Using json, data was stored and managed.
 - The camera did not move, but used a method of moving the map.
 - We have created additional quests using the dictionary.
 - We used the method of loading an object with AssetDatabase.LoadAssetAtPath().
 - Colliders are judged based on the material name of the collider.
 - It is designed to iteratively move the map using an algorithm that recycles three maps.
 - The left and right movement of the car is designed to look natural using linear interpolation.
 - Time.timescale separates game overs and game runs.
 - We implemented a car detection sensor using Raycast.
 - Two spotlights were attached to the car object to implement a car headlight.
 - After making another camera, I implemented navigation using render texture.

***Design Pattern***
 - Singleton
 - Component
 
***Resolution***
 - Free Aspect
