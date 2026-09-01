# Apply Discounts at Once

## Status

Complete

## Context

Logic for checking if a discount is applicable is repeated.

## Decision

During checkout, find all applicable discounts and apply them across the cart one time before calculating prices.

## Consequences

- DRY code results in less maintenance and increased extendability later on