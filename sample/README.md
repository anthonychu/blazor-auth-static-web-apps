### Run sample

```bash
# Install Static Web Apps CLI
npm i -g @azure/static-web-apps-cli

cd sample
cp api/local.settings.sample.json api/local.settings.json
cd app
swa start http://localhost:5000 --api ../api --run "dotnet run"
```

Browse to `http://localhost:4280`.