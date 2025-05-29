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

        var hoteis = await _context.Hotel.AsNoTracking()
           .Select(h => new GetAllHoteis
           {
             Id = h.Id,
             Name = h.Name,
             Description = h.Description,
             Url = h.Url,
             PhotosStared = h.Photos.Where(w => w.Stared == true).Select(x => x.Url)
           }).ToListAsync();

        return hoteis;
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
                                        .Include(h => h.Contacts)
                                        .Include(h => h.Photos)
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
        var novoId = Guid.NewGuid();

        var contatos = hotel.Contacts?.Select(c => new ContatosModel
        {
          Id = Guid.NewGuid(),
          Name = c.Name,
          Contact = c.Contact,
          DetalhesModelId = novoId
        }).ToList() ?? new List<ContatosModel>();

        var fotos = hotel.Photos?.Select(f => new FotosDetalhesModel
        {
          Id = Guid.NewGuid(),
          Alt = f.Alt,
          Url = f.Url,
          DetalhesModelId = novoId
        }).ToList() ?? new List<FotosDetalhesModel>();

        var hotelNew = new DetalhesModel
        {
          Id = novoId,
          Name = hotel.Name,
          Rede = hotel.Rede,
          City = hotel.City,
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
          Lobby = hotel.Lobby,
          Diff = hotel.Diff,
          Beach = hotel.Beach ?? false,
          Downtown = hotel.Downtown ?? false,
          Airpot = hotel.Airpot ?? false,
          Highway = hotel.Highway ?? false,
          Hospital = hotel.Hospital ?? false,
          Coffee = hotel.Coffee ?? false,
          Wifi = hotel.Wifi ?? false,
          Swimming = hotel.Swimming ?? false,
          Cleaning = hotel.Cleaning ?? false,
          Gym = hotel.Gym ?? false,
          Contacts = contatos,
          Photos = fotos
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

    public async Task<IActionResult> PutDetalhesfacade(string id, DetalhesModel hotel)
    {
      try
      {
        var hotelId = Guid.Parse(id);
        var hotelExistente = await _context.Hotel
          .Include(h => h.Contacts)
          .Include(h => h.Photos)
          .FirstOrDefaultAsync(h => h.Id == hotelId);

        if (hotelExistente == null)
          return new NotFoundObjectResult("Hotel não encontrado.");

        // Atualiza propriedades simples
        hotelExistente.Name = hotel.Name;
        hotelExistente.Rede = hotel.Rede;
        hotelExistente.City = hotel.City;
        hotelExistente.Url = hotel.Url;
        hotelExistente.Description = hotel.Description;
        hotelExistente.Category = hotel.Category;
        hotelExistente.Child = hotel.Child ?? false;
        hotelExistente.Pets = hotel.Pets ?? false;
        hotelExistente.PetsTax = hotel.PetsTax;
        hotelExistente.Cep = hotel.Cep;
        hotelExistente.Address = hotel.Address;
        hotelExistente.Number = hotel.Number;
        hotelExistente.Complement = hotel.Complement;
        hotelExistente.Lobby = hotel.Lobby;
        hotelExistente.Diff = hotel.Diff;
        hotelExistente.Beach = hotel.Beach ?? false;
        hotelExistente.Downtown = hotel.Downtown ?? false;
        hotelExistente.Airpot = hotel.Airpot ?? false;
        hotelExistente.Highway = hotel.Highway ?? false;
        hotelExistente.Hospital = hotel.Hospital ?? false;
        hotelExistente.Coffee = hotel.Coffee ?? false;
        hotelExistente.Wifi = hotel.Wifi ?? false;
        hotelExistente.Swimming = hotel.Swimming ?? false;
        hotelExistente.Cleaning = hotel.Cleaning ?? false;
        hotelExistente.Gym = hotel.Gym ?? false;

        // Atualiza contatos
        hotelExistente.Contacts = hotel.Contacts?.Select(c => new ContatosModel
        {
          Id = Guid.NewGuid(),
          Name = c.Name,
          Contact = c.Contact,
          DetalhesModelId = hotelId
        }).ToList() ?? new List<ContatosModel>();

        // Atualiza fotos
        hotelExistente.Photos = hotel.Photos?.Select(f => new FotosDetalhesModel
        {
          Id = Guid.NewGuid(),
          Alt = f.Alt,
          Url = f.Url,
          Stared = f.Stared,
          DetalhesModelId = hotelId
        }).ToList() ?? new List<FotosDetalhesModel>();

        _context.Hotel.Update(hotelExistente);
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
