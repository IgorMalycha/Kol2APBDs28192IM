﻿using Kol2APBD.DTOs;
using Kol2APBD.Models;

namespace Kol2APBD.Services;

public interface IDbService
{
    Task<Owner> GetOwnerData(int id);
    Task<bool> DoesOwnerExist(int id);
    Task AddOwnerWithObjects(AddOwnerWithObjectsRequestDTO addOwnerWithObjectsRequestDto);
    Task<bool> DoesObjectsExist(IEnumerable<int> objectsIds);
}