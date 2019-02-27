# Lykke.Bil2.Templates

`dotnet new` CLI templates for blockchain integration services - sign service, transaction executor and block reader.

## Templates included

- `lkebil2sign`
- `lkebil2tx`
- `lkebil2blocks`

## How to use

1. Clone repository to a local folder;
2. Install templates. For each internal directory run:

    ```bash
    $ dotnet new -i ${path}
    ```

    where `${path}` is the path to the template directory (where folder .template.config placed). On Windows it must be the __full__ path __without trailing slash__.

    ### Example

    To install __blocks reader__ template run

    ```bash
    dotnet new -i ./Lykke.Bil2.Templates/Lykke.Bil2.BlocksReader
    ```

3. Generate solutions:

    Generally, run

    ```bash
    dotnet new ${templateName} -n ${integrationName} -o ${outputPath}
    ```

    to generate solution in specified directory.

    Or create directory with required name, `cd` into created directory and run

    ```bash
    dotnet new ${templateName} -n ${integrationName}
    ```

    to generate solution from the inside.

## Examples

### Sign service

```bash
dotnet new lkebil2sign -n Bitcoin -o Lykke.Bil2.Bitcoin.SignService
```

For sign service implementation details see [Lykke.Bil2.Bcn.SignService/IMPLEMENTATION.md](Lykke.Bil2.Bcn.SignService/IMPLEMENTATION.md).

### Transactions executor

```bash
dotnet new lkebil2tx -n Bitcoin -o Lykke.Bil2.Bitcoin.TransactionsExecutor
```
For transactions executor implementation details see [Lykke.Bil2.Bcn.TransactionsExecutor/IMPLEMENTATION.md](Lykke.Bil2.Bcn.TransactionsExecutor/IMPLEMENTATION.md).

### Blocks reader

Blocks reader template contains additional parameter `-is` (or `--irreversibilityStrategy`) for irreversible block obtaining strategy, one of `none|pull|push`, if not specified - `none` is used:

```bash
dotnet new lkebil2blocks -n Bitcoin -o Lykke.Bil2.Bitcoin.BlocksReader -is none|pull|push
```

Use `none` or skip `-is` parameter if blockchain does not support irreversible blocks.

Use `push` model if used blockchain tools allow to determine changes of last irreversible block number (f.e. via web-sockets). `IrreversibleBlockHandler` class and corresponding registrations are generated in this case. Use `IIrreversibleBlockListener` provided by DI to emit `LastIrreversibleBlockUpdatedEvent`.

Use `pull` model if dedicated request is required to retrieve irreversible block data. `IrreversibleBlockProvider` class and corresponding registrations are generated in this case.

For transactions executor implementation details see [Lykke.Bil2.Bcn.BlocksReader/IMPLEMENTATION.md](Lykke.Bil2.Bcn.BlocksReader/IMPLEMENTATION.md).
