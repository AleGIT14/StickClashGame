using System;

public class Usuario
{

    public int id { get; set; }
    public string role { get; set; }
    public string name { get; set; }
    public string pass { get; set; }
    public string create_time { get; set; }

    public Usuario(int id, string role, string name, string pass, string create_time)
    {
        this.id = id;
        this.role = role;
        this.name = name;
        this.pass = pass;
        this.create_time = create_time;
    }

    public override string ToString()
    {
        return base.ToString();
    }
}
