using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using GameStore.Frontend.Converters;

namespace GameStore.Frontend.Models;

public class CustomerDetails
{   
     public int Id { get; set; }

    public required string Name { get; set; }

    public required string Email { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public required string Address { get; set; }
}