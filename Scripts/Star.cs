using Godot;
using System;

public class Star : Node2D {

    [Export]
    int radius;

    [Export]
    string name;

    [Export]
    int element;

    [Export]
    float magnitude;

    Telescope telescopeRoot;

    Label starName;
    
    Label starElement;
    Label starMag;

    bool infoVisible = false;
    
    public override void _Ready() {
        telescopeRoot = GetParent<Telescope>();
        
        starName = GetNode<Label>("StarName");
        
        starElement = GetNode<Label>("StarElement");
        starMag = GetNode<Label>("StarMagnitude");

        starName.Text = name;

        starElement.Text = element.ToString();
        starMag.Text = magnitude.ToString();

        BeInvis();
    }
    
    public override void _Process(float delta) {
        Vector2 msPos = GetViewport().GetMousePosition();

        Vector2 adjPos = Position - new Vector2(telescopeRoot.skyRotation, 0);

        float msDist = Mathf.Sqrt(Mathf.Pow(msPos.x - adjPos.x, 2) + Mathf.Pow(msPos.y - adjPos.y, 2));
        
        if(msDist <= radius && !infoVisible){
            BeVisible();
        }
        
        if(msDist > radius && infoVisible){
            BeInvis();
        }
    }
    
    public void BeVisible(){
        starName.Visible = true;
        
        starElement.Visible = true;
        starMag.Visible = true;

        infoVisible = true;
    }
    
    public void BeInvis(){
        starName.Visible = false;
        
        starElement.Visible = false;
        starMag.Visible = false;

        infoVisible = false;
    }
}