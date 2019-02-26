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

    where `${path}` is the __full__ path to the template directory (where folder .template.config placed) __without trailing slash__.

3. Generate solutions:

    Use

    ```bash
    dotnet new ${templateName} -n ${integrationName} -o ${outputPath}
    ```

    to generate solution is specified directory.

    Or create directory with required name, `cd` into created directory and use

    ```bash
    dotnet new ${templateName} -n ${integrationName}
    ```

    to generate solution from the inside.

    I.e. to create sign service solution for Bitcoin blockchain integration use:

    ```bash
    dotnet new lkebcnsign -n Bitcoin -o ./Lykke.Bil2.Bitcoin.SignService
    ```

    or create new directory, rename it to `Lykke.Bil2.Bitcoin.SignService` and run from the inside:

    ```bash
    dotnet new lkebcnsign -n Bitcoin 
    ```