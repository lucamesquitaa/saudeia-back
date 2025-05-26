using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaudeIA.Data;
using SaudeIA.Facades.Interfaces;
using SaudeIA.Models;
using SaudeIA.Models.DTOs;

namespace SaudeIA.Facades
{
  public class HotelFacade : IHotelFacade
  {
    private readonly Context _context;

    public HotelFacade(Context context)
    {
      _context = context;
    }

    public async Task<IEnumerable<GetAllHoteis>> GetAllFacade()
    {
      try
      {
        
        GetAllHoteis hoteis = await _context.Hotel.AsNoTracking()
                                              .Select(h => new GetAllHoteis
                                              {
                                                Id = h.Id,
                                                Name = h.Name,
                                                Url = h.Url
                                              }).ToListAsync();

        return (IEnumerable<GetAllHoteis>)hoteis;
      }
      catch (Exception e)
      {
        return null;
      }
    }
    public async Task<IEnumerable<DetalhesModel>> GetDetalhesFacade(string hotelId)
    {
      try
      {
        var hotel = await _context.Hotel.Where(u => u.Id.ToString() == hotelId)
                                        .AsNoTracking().ToListAsync();
          
        return hotel;
      }
      catch (Exception e)
      {
        return null;
      }
    }

    public async Task<IActionResult> PostDetalhesFacade(DetalhesModel hotel)
    {
      try
      {

        var hotelNew = new DetalhesModel
        {
          Id = Guid.NewGuid(), // novo Id
          Name = hotel.Name,
          Url = hotel.Url,
          Description = hotel.Description,
          Category = hotel.Category,
          Child = hotel.Child,
          Pets = hotel.Pets,
          PetsTax = hotel.PetsTax,
          Cep = hotel.Cep,
          Address = hotel.Address,
          Number = hotel.Number,
          Complement = hotel.Complement,
          Beach = hotel.Beach,
          Downtown = hotel.Downtown,
          Airpot = hotel.Airpot,
          Highway = hotel.Highway,
          Hospital = hotel.Hospital,
          Coffee = hotel.Coffee,
          Wifi = hotel.Wifi,
          Swimming = hotel.Swimming,
          Cleaning = hotel.Cleaning,
          Gym = hotel.Gym,
          Contacts = hotel.Contacts?.ToList() ?? new List<ContatosModel>(),
          Photos = hotel.Photos?.ToList() ?? new List<FotosDetalhesModel>()
        };

        await _context.Hotel.AddAsync(hotelNew);
        await _context.SaveChangesAsync();
        return new OkResult();
      }
      catch (Exception e)
      {
        return new BadRequestObjectResult(e.Message);
      }
    }
    public async Task<IActionResult> DeleteDetalhesFacade(string id)
    {
      try
      {
        var hotel = await _context.Hotel.Where(u => u.Id.ToString() == id).FirstOrDefaultAsync();
        if (hotel == null)
        {
          return new BadRequestObjectResult("Hotel não encontrada.");

        }
        _context.Hotel.Remove(hotel);
        await _context.SaveChangesAsync();
        return new OkResult();
      }
      catch (Exception e)
      {
        return new BadRequestObjectResult(e);
      }
    }
  }
}
