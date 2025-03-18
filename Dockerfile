FROM mcr.microsoft.com/dotnet/sdk:8.0

WORKDIR /app

COPY . /app/

EXPOSE 5180

# Instala o debugger do VS Code
RUN apt-get update && apt-get install -y unzip \
    && curl -L https://aka.ms/getvsdbgsh | bash /dev/stdin -v latest -l /vsdbg

ENTRYPOINT ["tail", "-f", "/dev/null"]
