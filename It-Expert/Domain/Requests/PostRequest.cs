﻿using It_Expert.Domain.Dtos;

namespace It_Expert.Domain.Requests;

public class PostRequest
{
    public DataDto[] Data { get; set; } = [];
}
