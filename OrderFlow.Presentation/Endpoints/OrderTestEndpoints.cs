﻿using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;
using OrderFlow.Application.Handlers.Users.Commands.CreateUserCommand;

namespace OverFlow.Presentation.Endpoints;

public class OrderTestEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/orders");

        //v1
        group.MapPost(
            string.Empty, async (ISender sender) => {
                var command = new CreateUserCommand("Jorge", "murillojulio.dev@outlook.com");

                var result = await sender.Send(command);

                return result.IsSuccess ? Results.Ok(result.Data) : Results.BadRequest();
            }
        );


        //v2
        group.MapGet("", GetOrders);
        group.MapGet("{id}", GetOrder);
    }


    private static async Task<IResult> GetOrders() => Results.Ok();

    //better api contract with swagger
    private static async Task<Results<Ok<int>, NotFound<string>>> GetOrder(string id) => TypedResults.Ok(10);


    private static async Task<IResult> CreateOrder() => Results.Ok();
}