import { LAYOUT } from '../config/layout.js'

function deviceId(name) {
  return `device:${name}`
}

function serviceId(deviceName, serviceName) {
  return `service:${deviceName}/${serviceName}`
}

function containerId(deviceName, serviceName, containerName) {
  return `container:${deviceName}/${serviceName}/${containerName}`
}

function edgeId(source, target) {
  return `${source}->${target}`
}

function createNode(id, type, label, position) {
  return {
    id,
    type,
    position,
    data: { label },
  }
}

function createEdge(source, target) {
  return {
    id: edgeId(source, target),
    source,
    target,
  }
}

export function buildGraph(devices) {
  const nodes = []
  const edges = []
  let y = 0

  for (const device of devices) {
    const currentDeviceId = deviceId(device.Name)

    nodes.push(
      createNode(currentDeviceId, 'device', device.Name, {
        x: LAYOUT.columnX,
        y,
      }),
    )

    y += LAYOUT.levelHeight

    for (const service of device.Services ?? []) {
      const currentServiceId = serviceId(device.Name, service.Name)

      nodes.push(
        createNode(currentServiceId, 'service', service.Name, {
          x: LAYOUT.columnX,
          y,
        }),
      )

      edges.push(createEdge(currentDeviceId, currentServiceId))

      y += LAYOUT.levelHeight

      for (const container of service.Containers ?? []) {
        const currentContainerId = containerId(
          device.Name,
          service.Name,
          container.Name,
        )

        nodes.push(
          createNode(currentContainerId, 'container', container.Name, {
            x: LAYOUT.columnX,
            y,
          }),
        )

        edges.push(createEdge(currentServiceId, currentContainerId))

        y += LAYOUT.levelHeight
      }
    }

    y += LAYOUT.blockGap
  }

  return { nodes, edges }
}
