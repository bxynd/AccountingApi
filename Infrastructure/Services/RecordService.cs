using Application.Dto;
using Application.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class RecordService : IRecordService
{
    private readonly IGenericRepository<Record> _recordRepository;

    public RecordService(IGenericRepository<Record> recordRepository)
    {
        _recordRepository = recordRepository;
    }
    public async Task<Record> AddRecord(RecordDto recordDto)
    {
        var record = new Record
        {
            Date = recordDto.Date.Equals(null)?DateTime.Now.ToUniversalTime() :recordDto.Date,
            Amount = recordDto.Amount,
            UserId = recordDto.UserId,
            ExpenseIncomeId = recordDto.ExpenseIncomeId,
            Comment = recordDto.Comment
        };
        await _recordRepository.Create(record);
        return record;
    }

    public async Task<Record> UpdateRecord(Guid id,RecordDto recordDto)
    {
        var record = await _recordRepository.ReadById(id);
        record.Date = recordDto.Date.Equals(null) ? DateTime.Now.ToUniversalTime() : recordDto.Date;
        record.Amount = recordDto.Amount;
        record.Comment = recordDto.Comment;
        record.UserId = recordDto.UserId;
        record.ExpenseIncomeId = recordDto.ExpenseIncomeId;
        await _recordRepository.Update(record);
        return record;
    }
    public async Task<List<Record>> GetAllRecords()
    {
        return await _recordRepository.ReadAll();
    }

    public async Task<Record> GetRecordById(Guid id)
    {
        return await _recordRepository.ReadById(id);
    }
    public async Task<Guid> DeleteRecord(Guid id)
    {
        await _recordRepository.Delete(id);
        return id;
    }
}