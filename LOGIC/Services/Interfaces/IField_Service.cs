using LOGIC.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface IField_Service
    {
        Task<Field_ResultSet> AddField(long user_id, string title, string vegetation, string square, string humidity, string status, DateTime date);

        Task<Field_ResultSet> GetFieldById(long field_id);

        Task<Field_ResultSet> UpdateField(long field_id, long user_id, string title, string vegetation, string square, string humidity, string status, DateTime date);

        Task<List<Field_ResultSet>> GetFieldsByUserId(long user_id);

        Task<List<Field_ResultSet>> GetAllFields();

        Task<bool> DeleteFieldById(long field_id);
    }
}
