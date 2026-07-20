# Homelab Docs

A GitHub-Pages-powered automatic visualization of your Docker homelab configuration.

This repository contains:

- A .NET parser that scans Docker Compose files and generates a service mapping.
- A web-based visualizer that displays your infrastructure.
- GitHub Actions automation to build the parser, generate the mapping, build the website, and deploy it to GitHub Pages.

The repository is designed to be forked. Your own Docker Compose repository can be connected as a private submodule, allowing you to keep infrastructure details private while still using this visualization.

Want to run the project? Navigate to the [Getting Started Guide](https://github.com/HomelabDocs/HomelabDocs/wiki/0.-Getting-Started) on the wiki! 

## Integrations

This project has a few integration regarding the docker-compose files, which mostly reads specific configuration labels and reflects these on the visualizer:

| Tool | Label | Purpose |
| --- | --- | --- |
| [Homepage](https://gethomepage.dev/) | `homepage.icon` | Loading icons on services. |
| [Traefik](https://traefik.io/traefik) | `traefik.http.routers.[name].rule` | Display routes on containers |
