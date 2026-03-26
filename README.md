# Animation Tutorial
## Blend tree
1. Add an animator component to the Y bot.
2. Create a animation controller and add it to the component.
3. Setup the Blend Tree
	1. On the base layer of the animation controller, add a blend tree. Change it's type to 2D Freeform Directional. 
	2. Create parameters "VelocityX" and "VelocityZ" of type float in the animator. Add these as the blend tree's parameters as well.
	3. Add the animation clips for walking, running and idle found in `Assets/Animations/Clips` to the Blend Tree. Change the Velocity X and Z of every clip to match the direction and speed, so for example idle would be (0, 0), walk forward would be (0, 1) and run forward would be (0, 2).
4. In the player script, setup the script to update the animator's parameters previously mentioned.
	1. Get the animator component of the player object. Get the hashes of the velocity variables as well.
	2. In the update method, set the animator's parameters to match the movement speed using `animator.SetFloat(hash, value)` for both the x and z velocity.
## Animation Layers and Masks
1. In the animation controller, add a new layer for the torch. 
	1. Set its weight to `0.1`.
	2. Create an avatar mask for the YBot and add it to the layer.
	3. In the inspector, while the mask is selected, import the `Y BotAvatar` as a skeleton and deselect all nodes except for `maxamorig:LeftShoulder` and its children.
2. In the Animator window, setup the states.
	1. Create an empty clip by right clicking for the default state.
	2. Add the animations in `Assets/Animations/Clip/Torch` to this layer. Add the `Equip Torch` clip twice, name the second one "Unequip Torch" and change its speed to `-1`. 
	3. Add a new bool parameter to the animator named `IsTorchEquipped`.
	4. Add transitions between the states so they go  like `Empty -> Equip -> Idle -> Unequip -> Empty`. 
		1. For the transition from Empty to Equip, turn off `Has Exit Time` and add a condition for `IsTorchEquipped == true`.
		2. For the transition from `Idle` to `Unequip`, turn off `Has Exit Time` and add a condition for `IsTorchEquipped == false`.
3. In the player script, setup the script so it updates the `IsTorchEquipped` variable is toggled to true or false in the `OnAttack` method.
	1. Add a bool `isTorchEquipped` to save whether the torch is equipped with a default value of false. Add a variable to save the hash of the `IsTorchEquipped` variable as well.
	2. In the `OnAttack` method, switch the script's `isTorchEquipped` to the opposite value and update the animator's parameter to match using `animator.SetBool(hash, value)`.
## Toggle torch visibility using events
1. Open the Y Bot in the "Animation" window. In there, select the "Equip Torch" clip, and find the moment in time you want the torch to appear at. Right click to add an animation event at that point in time.
2. In the player script, add a public method to toggle the activeness of the torch using the `SetActive` and `activeSelf` methods on the torch.
3. Add this method to the animation event.
