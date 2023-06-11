using System;

public class Usuario
{

    public int id { get; set; }
    public string role { get; set; }
    public string status { get; set; }
    public string name { get; set; }
    public string pass { get; set; }
    public string create_time { get; set; }

    public Usuario(int id, string role, string name, string pass, string status)
    {
        this.id = id;
        this.role = role;
        this.name = name;
        this.pass = pass;
        this.status = status;
    }

    public Usuario(int id, string status, string name)
    {
        this.id = id;
        this.status = status;
        this.name = name;
    }

    public override string ToString()
    {
        return id + " - " + name + " - " + pass;
    }
}
