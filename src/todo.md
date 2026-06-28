# Todo List for Mumbai Weather FastAPI Service

## Setup
- [x] Initialize Python virtual environment
- [x] Install dependencies: fastapi, uvicorn, httpx, python-dotenv, pytest, pytest-asyncio
- [x] Freeze requirements.txt

## Development
- [x] Implement WeatherService class in app/services.py
- [x] Refactor app/main.py to use WeatherService
- [x] Load OpenWeather API key from environment variable
- [x] Add error handling for HTTP and request errors

## Testing
- [x] Create tests/test_main.py to test /weather/mumbai endpoint
- [x] Mock external OpenWeather API calls in tests

## Security
- [ ] Ensure API key is never hardcoded, only loaded from environment variables
- [ ] Validate all external inputs and handle errors gracefully

## Documentation
- [ ] Document setup and usage instructions