using System;

namespace Application.Activities.DTOs;

public class BaseActivityDto
{    public  string Title { get; set; } = "";

    public DateTime Date { get; set; }

    public  string Description { get; set; }= String.Empty;
    public  string Category { get; set; } =  "";
    //location Props

    public  string City { get; set; } =String.Empty;

    public  string Venue { get; set; } = String.Empty;

    public double Latitude { get; set; }

    public double Longitude { get; set; }

}
