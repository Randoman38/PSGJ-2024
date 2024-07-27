using Godot;
using System;

public class HorizLever : Node2D {

    bool sliderGrabbed = false;

    float rotSpeed = 0f;
    
    Sprite slider;
    
    public override void _Ready() {
        slider = GetNode<Sprite>("Slider");
    }
    
    public override void _Process(float delta) {
        Vector2 msPos = GetViewport().GetMousePosition();
        Vector2 adjmsPos = msPos - Position;
        
        if((adjmsPos.x >= slider.Position.x && adjmsPos.x < slider.Position.x + slider.Texture.GetWidth()) && (adjmsPos.y >= slider.Position.y && adjmsPos.y < slider.Position.y + slider.Texture.GetHeight())){
            if(Input.IsActionJustPressed("LMB") && !sliderGrabbed){
                sliderGrabbed = true;
            }
        }
        
        if(Input.IsActionJustReleased("LMB") && sliderGrabbed){
            sliderGrabbed = false;
        }

        if (sliderGrabbed) {
            if(Mathf.Abs((adjmsPos.x - (adjmsPos.x % 20)) - adjmsPos.x) <= 5f){
                int newSliderX = (int) Mathf.Clamp((adjmsPos.x - (adjmsPos.x % 20)), -40f, 40f) - 3;

                slider.Position = new Vector2((float)newSliderX, -5);

                rotSpeed = (newSliderX + 3) / 20f;
            }
        }
    }
    
    public float GetRotSpeed(){
        return rotSpeed;
    }
}