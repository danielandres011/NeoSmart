﻿using Microsoft.EntityFrameworkCore;
using NeoSmart.BackEnd.Interfaces;
using NeoSmart.ClassLibraries.Entities;
using NeoSmart.ClassLibraries.Enum;
using NeoSmart.ClassLibraries.Responses;
using NeoSmart.Data.Entities;

namespace NeoSmart.BackEnd.Helper
{
    public class InscriptionsHelper : IInscriptionsHelper
    {
        private readonly DataContext _context;

        public InscriptionsHelper(DataContext context)
        {
            _context = context;
        }
        public async Task<Response<bool>> ProcessInscriptionAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (user == null)
            {
                return new Response<bool>
                {
                    IsSuccess = false,
                    Message = "Usuario no válido"
                };
            }

            var temporalInscriptions = await _context.TemporalInscriptions
                .Include(x => x.Training)
                .Where(x => x.User!.Email == email)
                .ToListAsync();

            foreach (var temporalInscription in temporalInscriptions)
            {
                Inscription inscription = new()
                {
                    Date = DateTime.UtcNow,
                    User = user,
                    Remarks = temporalInscription.Remarks,
                    Training = temporalInscription.Training,
                    InscriptionStatus = InscriptionStatus.Registered
                };
                _context.Inscriptions.Add(inscription);
                //Enviar email
                _context.TemporalInscriptions.Remove(temporalInscription);
            }

            await _context.SaveChangesAsync();

            return new Response<bool>() { IsSuccess = true };
        }
    }
}