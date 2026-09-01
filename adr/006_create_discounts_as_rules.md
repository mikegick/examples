# Create Discounts as Rules

## Status

Completed

## Context

Discounts are currently hard-coded as complex branching logic

## Decision

Create discounts as objects that can be represented as data

## Consequences

- Discounts can be stored in a database and can be changed without code deploy
- Code to apply discounts will not grow as more discounts are added