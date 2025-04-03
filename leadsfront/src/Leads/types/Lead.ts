export interface Lead {
    id: number
    firstName: string
    fullName: string | undefined
    description: string
    category: string
    suburb: string
    price: number
    dateCreated: string   
    email: string | undefined
    phone: string | undefined

}