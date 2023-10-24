using DAL.Entities;
using DAL.Functions.CRUD;
using DAL.Functions.Interfaces;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementations
{
    public class Field_Service : IField_Service
    {
        private ICrud _crud = new Crud();

        public async Task<Field_ResultSet> AddField
            (long user_id, string title, string vegetation, string square, string humidity, string status, DateTime date)
        {
            try
            {
                Field field = new Field
                {
                    UserId = user_id,
                    Title = title,
                    Vegetation = vegetation,
                    Square = square,
                    Humidity = humidity,
                    Status = status,
                    Date = date
                };

                field = await _crud.Create<Field>(field);

                Field_ResultSet fieldAdded = new Field_ResultSet
                {
                    field_id = field.FieldId,
                    user_id = field.UserId,
                    title = field.Title,
                    vegetation = field.Vegetation,
                    square = field.Square,
                    humidity = field.Humidity,
                    status = field.Status,
                    date = field.Date
                };

                return fieldAdded;
            }
            catch (Exception)
            {
                throw new Exception("We failed to register your information for your Field. Please try again.");
            }
        }

        public async Task<bool> DeleteFieldById(long field_id)
        {
            try
            {
                bool isFieldDeleted = await _crud.Delete<Field>(field_id);

                return isFieldDeleted;
            }
            catch (Exception)
            {
                throw new Exception("We failed find the Field you are looking for.");
            }
        }

        public async Task<List<Field_ResultSet>> GetAllFields()
        {
            try
            {
                List<Field> fields = await _crud.ReadAll<Field>();

                List<Field_ResultSet> result = new List<Field_ResultSet>();
                fields.ForEach(f =>
                {
                    result.Add(new Field_ResultSet
                    {
                        field_id = f.FieldId,
                        user_id = f.UserId,
                        title = f.Title,
                        vegetation = f.Vegetation,
                        square = f.Square,
                        humidity = f.Humidity,
                        status = f.Status,
                        date = f.Date
                    });
                });

                return result;
            }
            catch (Exception)
            {
                throw new Exception("We failed fetch all the required pets statuses from the database.");
            }
        }

        public async Task<Field_ResultSet> GetFieldById(long field_id)
        {
            try
            {
                Field field = await _crud.Read<Field>(field_id);

                Field_ResultSet fieldReturned = new Field_ResultSet
                {
                    field_id = field.FieldId,
                    user_id = field.UserId,
                    title = field.Title,
                    vegetation = field.Vegetation,
                    square = field.Square,
                    humidity = field.Humidity,
                    status = field.Status,
                    date = field.Date
                };

                return fieldReturned;
            }
            catch (Exception)
            {
                throw new Exception("We failed find the Field you are looking for.");
            }
        }

        public async Task<List<Field_ResultSet>> GetFieldsByUserId(long user_id)
        {
            try
            {
                List<Field> field = await _crud.ReadAll<Field>();

                var filteredFields = field.Where(f => f.UserId == user_id).ToList();

                List<Field_ResultSet> result = new List<Field_ResultSet>();
                filteredFields.ForEach(f =>
                {
                    result.Add(new Field_ResultSet
                    {
                        field_id = f.FieldId,
                        user_id = f.UserId,
                        title = f.Title,
                        vegetation = f.Vegetation,
                        square = f.Square,
                        humidity = f.Humidity,
                        status = f.Status,
                        date = f.Date
                    });
                });

                return result;
            }
            catch (Exception)
            {
                throw new Exception("We failed fetch all the required Field statuses from the database.");
            }
        }

        public async Task<Field_ResultSet> UpdateField
            (long field_id, long user_id, string title, string vegetation, string square, string humidity, string status, DateTime date)
        {
            try
            {
                Field fieldToUpdate = new Field
                {
                    FieldId = field_id,
                    UserId = user_id,
                    Title = title,
                    Vegetation = vegetation,
                    Square = square,
                    Humidity = humidity,
                    Status = status,
                    Date = date
                };

                fieldToUpdate = await _crud.Update<Field>(fieldToUpdate, field_id);

                Field_ResultSet fieldUpdated = new Field_ResultSet
                {
                    field_id = fieldToUpdate.FieldId,
                    user_id = fieldToUpdate.UserId,
                    title = fieldToUpdate.Title,
                    vegetation = fieldToUpdate.Vegetation,
                    square = fieldToUpdate.Square,
                    humidity = fieldToUpdate.Humidity,
                    status = fieldToUpdate.Status,
                    date = fieldToUpdate.Date
                };

                return fieldUpdated;
            }
            catch (Exception)
            {
                throw new Exception("We failed to update the supplied Field.");
            }
        }
    }
}
