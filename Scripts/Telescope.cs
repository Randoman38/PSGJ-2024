using Godot;
using System;

public class Telescope : Node2D {

    public float skyRotation = 0f;
    float rotSpeed = 1f;

    public int skyWidth;
    
    Sprite skySprite;

    HorizLever h_lever;
    
    public override void _Ready() {
        skySprite = GetNode<Sprite>("NightSky");

        skyWidth = skySprite.Texture.GetWidth();

        h_lever = GetNode<HorizLever>("HorizLever");
    }
    
    public override void _Process(float delta){
        float rotDir = h_lever.GetRotSpeed();
        
        skyRotation = (skyRotation + (rotSpeed * rotDir)) % skyWidth;
        
        float shaderOffset = skyRotation / skyWidth;
        
        ((ShaderMaterial)(skySprite.Material)).SetShaderParam("offset", shaderOffset);
    }
}