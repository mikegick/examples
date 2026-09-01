# Enums for Product Category

## Status

Completed

## Context

Using a string for Product Category can result in typos. String matching in the database is also slow compared to an integer.

## Decision

The Category field in Product will be changed to an enum.

## Consequences

- Faster querying
- More reliable data