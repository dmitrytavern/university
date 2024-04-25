const Algebrite = require("algebrite");

const fn = '1/(sqrt(2 * x^2 + 0.4 * 15))';
const fn1 = Algebrite.run(`d(${fn})`).replace(/\.\.\./g, "");
const fn2 = Algebrite.run(`d(${fn1})`).replace(/\.\.\./g, "");
const fn3 = Algebrite.run(`d(${fn2})`).replace(/\.\.\./g, "");
const a = 0.1
const b = 1.8
const n = 20
const h = (b - a) / n

const xes: number[] = []
const yes: number[] = []
const yces: number[] = []
const y1es: number[] = []
const y2es: number[] = []
const y3es: number[] = []

for (let i = 0; i < n; i++) {
  const x = (a + (i * h)).toFixed(4)
  xes.push(+x)
  yes.push(+Algebrite.run(fn.replace(/x/g, x)).replace(/\.\.\./g, ""))
  y1es.push(+Algebrite.run(fn1.replace(/x/g, x)).replace(/\.\.\./g, ""))
  y2es.push(+Algebrite.run(fn2.replace(/x/g, x)).replace(/\.\.\./g, ""))
  y3es.push(+Algebrite.run(fn3.replace(/x/g, x)).replace(/\.\.\./g, ""))
}

for (let i = 0; i < n; i++) {
  const x = (xes[i] + (xes[i + 1] || 0)) / 2
  yces.push(+Algebrite.run(fn.replace(/x/g, x.toString())).replace(/\.\.\./g, ""))
}

const riemann_left_rule_s = (() => {
  let sum = 0
  for (let i = 0; i < n - 1; i++) sum += yes[i]
  return h * sum
})().toFixed(8)

const riemann_left_rule_r = (() => {
  return ((n * h * h) / 2) * Math.max(...y1es)
})().toFixed(8)

console.log(`Riemann left rule: S = ${riemann_left_rule_s}; R = ${riemann_left_rule_r};`)

const riemann_right_rule_s = (() => {
  let sum = 0
  for (let i = 1; i < n; i++) sum += yes[i]
  return h * sum
})().toFixed(8)

const riemann_right_rule_r = (() => {
  return ((n * h * h) / 2) * Math.max(...y1es) 
})().toFixed(8)

console.log(`Riemann right rule: S = ${riemann_right_rule_s}; R = ${riemann_right_rule_r};`)

const riemann_midpoint_rule_s = (() => {
  let sum = 0
  for (let i = 0; i < n - 1; i++) sum += yces[i]
  return h * sum
})().toFixed(8)

const riemann_midpoint_rule_r = (() => {
  return ((n * h * h * h) / 24) * Math.max(...y2es) 
})().toFixed(8)

console.log(`Riemann midpoint rule: S = ${riemann_midpoint_rule_s}; R = ${riemann_midpoint_rule_r};`)

const trapezoidal_rule_s = (() => {
  let sum = 0
  for (let i = 1; i < n - 1; i++) sum += yes[i]
  return h * (((yes[0] + yes[n - 1]) / 2) + sum)
})().toFixed(8)

const trapezoidal_rule_r = (() => {
  return ((n * h * h * h) / 12) * Math.max(...y2es) 
})().toFixed(8)

console.log(`Trapezoidal rule: S = ${trapezoidal_rule_s}; R = ${trapezoidal_rule_r};`)

const simpsons_rule_s = (() => {
  let sum = 0
  for (let i = 0; i < (n / 2) - 1; i++) sum += yes[2 * i] + (4 * yes[2 * i]) + yes[2 * i + 2]
  return (h / 3) * sum
})().toFixed(8)

const simpsons_rule_r = (() => {
  return ((n * h * h * h * h * h) / 180) * Math.max(...y3es) 
})().toFixed(14)

console.log(`Simpson's rule: S = ${simpsons_rule_s}; R = ${simpsons_rule_r};`)
