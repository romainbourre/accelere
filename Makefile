# BUILD

build:
	dotnet build

build.image:
	docker build -t race-manager:latest .

# RUN

run:
	dotnet run --project Presenters/RacesManager.Api

# QUALITY

tests:
	dotnet test

mutate.business:
	dotnet stryker -p RacesManager.Application -tp Business/RacesManager.Application.Tests -o

mutate.adapters:
	dotnet stryker -p RacesManager.Adapters -tp Adapters/RacesManager.Adapters.Tests -o

mutate: mutate.business mutate.adapters

quality: tests mutate

# PUBLISHER

publish.api:
	dotnet publish --no-restore -c Release -o out/ Presenters/RacesManager.Api

# CLEAN

clean:
	dotnet clean
	find . -name StrykerOutput -type d -exec rm -rf {} \;
	find . -name bin -type d -prune -exec rm -rf {} \;
	find . -name obj -type d -prune -exec rm -rf {} \;

