import yaml

# Cargar el archivo de progreso
with open('progress.yml', 'r') as file:
    progress = yaml.safe_load(file)

# Calcular el porcentaje total de trabajo
total_percentage = sum(int(value.strip('%')) for value in progress.values()) / len(progress)

# Generar la barra de progreso en formato Markdown
progress_bar = f"![Team Progress](https://progress-bar.dev/{total_percentage}/)"

# Actualizar el archivo README.md
with open('README.md', 'a') as readme:
    readme.write('\n\n')
    readme.write(progress_bar)

