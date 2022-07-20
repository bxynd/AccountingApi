using Application.Dto;
using Domain.Models;

namespace Application.Interfaces;

public interface IRecordService
{
    Task<Record> AddRecord(RecordDto recordDto);
    Task<Record> UpdateRecord(Guid id,RecordDto recordDto);
    Task<List<Record>> GetAllRecords();
    Task<Record> GetRecordById(Guid id);
    Task<Guid> DeleteRecord(Guid id);
}