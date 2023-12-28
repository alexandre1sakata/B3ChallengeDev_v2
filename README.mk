## App client - angular

install:
		@ npm install

build:
		@ npm run build

start: 
		@ npm start

tests:
		@ ng test


## WebAPI - .netFramework472:

.netFramework472:
build: 
	Solution Explorer => B3ChallengeDev.WebAPI => BuildSolution

run:
	Solution Explorer => B3ChallengeDev.WebAPI => Debug => Start New Instance

test: 
	Solution Explorer => B3ChallengeDev.WebAPI => Run Tests
	

## WebAPI - .netCore6:

all : clean restore build publish

clean:
	dotnet clean

restore:
	dotnet restore

build: 
	dotnet build

run:
	dotnet run

test:
	dotnet test