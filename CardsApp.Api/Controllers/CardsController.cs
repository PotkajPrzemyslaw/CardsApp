using CardsApp.Api.Dtos;
using CardsApp.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CardsApp.Api.Controllers;

[Route("api/items/cards")]
[ApiController]
public class CardsController : ControllerBase
{
    private readonly ICardsService _service;

    public CardsController(ICardsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Gets all existing cards in game
    /// </summary>
    /// <returns>Collection of cards</returns>
    [HttpGet("GetCardsAsync")]
    [ActionName("GetCardsAsync")]
    public async Task<ActionResult<IEnumerable<CardDto>>> GetCardsAsync()
    {
        try
        {
            return Ok(await _service.GetCards());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Gets all existing cards in game using pagination
    /// </summary>
    /// <param name="page"></param>
    /// <param name="pageSize"></param>
    /// <returns>Collection of cards</returns>
    [HttpGet("GetCardsPageAsync")]
    [ActionName("GetCardsPageAsync")]
    public async Task<ActionResult<IEnumerable<CardDto>>> GetCardsPageAsync(int page, int pageSize)
    {
        try
        {
            return Ok(await _service.GetCards(page, pageSize));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Get single card
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Single Card</returns>
    [HttpGet("{id}")]
    [ActionName("GetCardAsync")]
    public async Task<ActionResult<CardDto>> GetCardAsync(int id)
    {
        try
        {
            return Ok(await _service.GetSingleCard(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Creates a card
    /// </summary>
    /// <param name="card">Card model</param>
    /// <returns>New created card id</returns>
    [HttpPost("CreateCardAsync")]
    [ActionName("CreateCardAsync")]
    public async Task<ActionResult<int>> CreateCardAsync(CreateCardDto card)
    {
        try
        {
            await _service.CreateCard(card);

            return CreatedAtAction(nameof(CreateCardAsync), card);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Delete single card
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [ActionName("DeleteCardAsync")]
    public async Task<ActionResult> DeleteCardAsync(int id)
    {
        try
        {
            await _service.DeleteCard(id);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}