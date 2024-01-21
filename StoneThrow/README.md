# Boulder throwing
This simulation has boulder flying up to the wall and breaking it in real time with sound effect
https://github.com/arthur100500/computer-graphics-course/assets/57834711/32edce16-e1f9-4a04-97e1-504712420ba5

# Creating steps

### Create new project in Unity
- Opened `Unity Hub` and created new project from template 3d (URP) to have Universal Render Pipeline for graphics.

### Create models for oulder and walls
- I downloaded boulder model from internet
- For plank model, I created simple cube in blender and modified it slightly
- For plank pieces, I used knife tool to cut plank into two pieces as though it was shattered

### Create scene
- Dragged objects into the `Unity` scene and combine them into wall and a boulder
- Set up physics for objects
  - Rigidbodies for stone and planks
  - Complex structure for each plank in wooden wall
  - Whole plank is activated and has `Rigidbody` + `Box collider`
  - 2 pieces have rigidbodies, boxcollider and spring joints configured to act as if planks were nailed to support
- Stone has script to set velocity on `OnStart`

### Single plank structure
- Every plank has 3 objects: 1 whole and 2 pieces. 2 pieces are deactivated
- On impact with boulder (`OnCollisionEnter()`) deactivate whole part and activate pieces, also play sound
