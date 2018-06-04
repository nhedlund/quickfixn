FROM microsoft/dotnet:2.1.300-sdk

RUN apt-get update
RUN apt-get install -y ruby ruby-nokogiri

COPY . /src
WORKDIR /src

RUN ./generate
RUN dotnet build
