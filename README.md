# Bombs

The way that Unity works is that you have an overarching scene space.  You can place Game Objects (2d or 3d models, lights, sounds, particle systems
UI components, etc) into that scene space.  The way that these game objects behave within the scene is dictated by the components that
are attached to them.  Some of the common components are transforms, rigidbodys, scripts, mesh renderers, and colliders.  But there are
obviously a lot more for more specific situations.

The transform is the only component that all game objects must have.  It is the Game Objects position and rotation.  Position is usually stored
as a Vector 3 which just means a point. Rotation is controlled using quaternions.  gameObject.transform.position references that game Objects position. 
"transform.position" in a script represents the position of gameobject that the script is attached to.  Rigidbodies are the components 
that you apply forces to.  Colliders can be used as triggers for events and can also be used as the boundary for the gameobject (like if you don't
want it to be able to just pass through a wall).  Each script is also applied to a specific gameObject and obviously if you say this.gameobject.something,
it is referring to the gameobject that the script is attached to in unity.

Any time that you see GetComponent<type>(); , it just means that you are assigning a certain component to a variable so that you can interact
with that component later in the script.

The way unity executes script is on their own internal timing system.  The specific order of events is described here:
 https://docs.unity3d.com/Manual/ExecutionOrder.html

The gist of it is that awake and start are run once in that order either upon loading of the scene or instantiation of a gameobject
Code within the Update() function is executed once per frame rate. FixedUpdate() is executed at a fixed interval.  Update is used for
most things that are involved with graphics.  FixedUpdate is used for anything that involves physics.
