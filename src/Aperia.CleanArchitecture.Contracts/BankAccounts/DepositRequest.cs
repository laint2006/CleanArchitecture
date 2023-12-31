﻿namespace Aperia.CleanArchitecture.Contracts.BankAccounts;

/// <summary>
/// The Deposit Request
/// </summary>
public record DepositRequest(decimal Amount, string? Reference);